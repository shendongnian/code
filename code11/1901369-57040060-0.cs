    using System;
    using Newtonsoft.Json;
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"{'post':{'Pseudo':{'value':'Clem'},'Titre':{'value':'mon article'},'Contenu':{'value':'Du texte, du texte, du texte'}}}";
    		var Sresponse = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine(Sresponse.post.Pseudo.value);
    		Console.WriteLine(Sresponse.post.Titre.value);
    		Console.WriteLine(Sresponse.post.Contenu.value);
    
    	}
    }
    
    public class Pseudo
    {
        public string value { get; set; }
    }
    
    public class Titre
    {
        public string value { get; set; }
    }
    
    public class Contenu
    {
        public string value { get; set; }
    }
    
    public class Post
    {
        public Pseudo Pseudo { get; set; }
        public Titre Titre { get; set; }
        public Contenu Contenu { get; set; }
    }
    
    public class RootObject
    {
        public Post post { get; set; }
    }
