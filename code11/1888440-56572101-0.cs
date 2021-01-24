    private static void Main()
    {
    	const string componentIndex = "componenttypeindex";
    	const string projectIndex = "projecttypeindex";
    
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
    	var settings = new ConnectionSettings(pool)
    		.DefaultIndex(componentIndex)
    		.DefaultMappingFor<ComponentTypES>(i => i.IndexName(componentIndex).TypeName("Componenttype").IdProperty(f => f.ComponentID))
    		.DefaultMappingFor<ProjectTypES>(j => j.IndexName(projectIndex).TypeName("Projecttype").IdProperty(f => f.ProjectID))
    		.DefaultFieldNameInferrer(f => f)
    		.DefaultTypeName("_doc")
            .DisableDirectStreaming()
            .PrettyJson()
            .OnRequestCompleted(callDetails =>
            {
                if (callDetails.RequestBodyInBytes != null)
                {
                    Console.WriteLine(
                        $"{callDetails.HttpMethod} {callDetails.Uri} \n" +
                        $"{Encoding.UTF8.GetString(callDetails.RequestBodyInBytes)}");
                }
                else
                {
                    Console.WriteLine($"{callDetails.HttpMethod} {callDetails.Uri}");
                }
    
                Console.WriteLine();
    
                if (callDetails.ResponseBodyInBytes != null)
                {
                    Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                             $"{Encoding.UTF8.GetString(callDetails.ResponseBodyInBytes)}\n" +
                             $"{new string('-', 30)}\n");
                }
                else
                {
                    Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                             $"{new string('-', 30)}\n");
                }
            });
    
        var client = new ElasticClient(settings);
    
    	foreach (var index in new[] { componentIndex, projectIndex }) 
    	{
    		if (client.IndexExists(index).Exists)
    			client.DeleteIndex(index);
    			
    		client.CreateIndex(index, c => c
    			.Mappings(m => {
    				if (index == projectIndex)
    					return m.Map<ProjectTypES>(mm => mm.AutoMap());
    				else
    					return m.Map<ComponentTypES>(mm => mm.AutoMap());
    			})
    		);
    	}
    	
    	client.Bulk(b => b
    		.IndexMany(new [] {
    			new ComponentTypES 
    			{
    				ComponentID = "5342e739-1635-4021-baf2-55e25b95b8ec",
    				Componentname = "TestComponent1",
    				Summary = "this is summary of test component1"
    			},
    			new ComponentTypES
    			{
    				ComponentID = "90781386-8065-11e9-bc42-526af7764f64",
    				Componentname = "TestComponent2",
    				Summary = "this is summary of test component3"
    			},
    			new ComponentTypES
    			{
    				ComponentID = "19871386-8065-11e9-bc42-526af7764f64",
    				Componentname = "some xyz component test",
    				Summary = "this is summary test of test xyz"
    			},
    		})
    		.IndexMany(new [] {
    			new ProjectTypES
    			{
    				ProjectID = "5342e739-2019-4021-baf2-55e25b95b8ec",
    				Projectname = "Test Project1",
    				Summary = "summary of Test Project1",
    				Description = "Description of TestProject1"
    			},
    			new ProjectTypES
    			{
    				ProjectID = "5342f739-2019-4021-baf2-55e25b95b8ba",
    				Projectname = "Test Project2",
    				Summary = "summary of Test Project2",
    				Description = "Description of TestProject1"
    			},
    			new ProjectTypES
    			{
    				ProjectID = "6342f739-2020-4021-baf2-55e25b95b8ac",
    				Projectname = "some PQRS project",
    				Summary = "summary of PQRS Project",
    				Description = "Description of PQORS Project1"
    			},
    		})
    		.Refresh(Refresh.WaitFor)
    	);
    	
    	var query = "test";
    
    	var response = client.Search<object>(s => s
    		.Index(Indices.Index(typeof(ComponentTypES)).And(typeof(ProjectTypES)))
    		.Type(Types.Type(typeof(ComponentTypES), typeof(ProjectTypES)))
    		.Query(q => 
    			(q
    				.MultiMatch(m => m
    					.Fields(f => f
    						.Field(Infer.Field<ComponentTypES>(ff => ff.Componentname))
    						.Field(Infer.Field<ComponentTypES>(ff => ff.Summary, 1.1))
    					)
    					.Operator(Operator.Or)
    					.Query(query)
    				) && +q
    				.Term("_index", componentIndex)
    			) || 
    			(q
    				.MultiMatch(m => m
    					.Fields(f => f
    						.Field(Infer.Field<ProjectTypES>(ff => ff.Projectname))
    						.Field(Infer.Field<ProjectTypES>(ff => ff.Summary, 0.3))
    					)
    					.Operator(Operator.Or)
    					.Query(query)
    				) && +q
    				.Term("_index", projectIndex)
    			)
    		)
    	);
    }
    
    public class ComponentTypES
    {
    	public string ComponentID { get; set; }
    	public string Componentname { get; set; }
    	public string Summary { get; set; }
    
    }
    
    public class ProjectTypES
    {
    
    	public string ProjectID { get; set; }
    	public string Projectname { get; set; }
    	public string Summary { get; set; }
    	public string Description { get; set; }
    }
