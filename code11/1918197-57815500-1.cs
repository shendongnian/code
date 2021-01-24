     [BsonIgnoreExtraElements]
     public class OrganizationWithWorkflows
     {
          public string Id { get; set; }
          public string Name { get; set; }
          public long WorkflowCounter {get; set;}
          public DateTime? LastDateUploaded { get; set; }
          public DateTime? LastDateEvaluated { get; set; }
          public int PriorityValue { get; set; }
     }
