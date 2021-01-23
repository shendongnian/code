    //Using a page "test.aspx" in my existing project (I already had it open)
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "{\"project\":[{\"name\":\"GCUK\",\"id\":\"project11\",\"href\":\"/httpAuth/app/rest/projects/id:project11\"},{\"name\":\"Interiors In Spain\",\"id\":\"project3\",\"href\":\"/httpAuth/app/rest/projects/id:project3\"}]}";
            var p = JsonConvert.DeserializeObject<TCProjectWrapper>( s );
            s = "this"; //for easy breakpointing
        }
    }
    [JsonObject( MemberSerialization.OptIn )]
    public class TCProjectWrapper {
        [JsonProperty( PropertyName = "project" )]
        private List<TCProject> Project { get; set; }
    }
    [JsonObject( MemberSerialization.OptIn )]
    public class TCProject {
        public override string ToString() {
            return Name;
        }
    
        [JsonProperty( PropertyName = "archived" )]
        public bool Archived { get; set; }
    
        [JsonProperty( PropertyName = "description" )]
        public string Description { get; set; }
    
        [JsonProperty( PropertyName = "href" )]
        public string Href { get; set; }
    
        [JsonProperty( PropertyName = "id" )]
        public string Id { get; set; }
    
        [JsonProperty( PropertyName = "name" )]
        public string Name { get; set; }
    
        [JsonProperty( PropertyName = "webUrl" )]
        public string WebUrl { get; set; }
    }
