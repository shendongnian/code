    using System.Web.Script.Serialization;
    ...
    public string getJson(){
       var publicationTable = new List<object>{
          new []{ 31422,"Abilene Reporter News","Abilene","TX",false,"D",0},
          new []{ 313844,"Acadiana Weekly","Opelousas","LA",false,"W",1 },
          new []{ 527825,"Action Advertiser","Fond du Lac","WI",false,"W",2}
       };
       return (new JavaScriptSerializer).Serialize(publicationTable);
    }
