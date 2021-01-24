    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"[{'faceId':'f7eda569-4603-44b4-8add-cd73c6dec644','faceRectangle':{'top':131,'left':177,'width':162,'height':162},'faceAttributes':{'smile':0,'headPose':{'pitch':0,'roll':0.1,'yaw':-32.9},'gender':'female','age':22.9,'facialHair':{'moustache':0,'beard':0,'sideburns':0},'glasses':'NoGlasses','emotion':{'anger':0,'contempt':0,'disgust':0,'fear':0,'happiness':0,'neutral':0.986,'sadness':0.009,'surprise':0.005},'blur':{'blurLevel':'low','value':0.06},'exposure':{'exposureLevel':'goodExposure','value':0.67},'noise':{'noiseLevel':'low','value':0},'makeup':{'eyeMakeup':true,'lipMakeup':true},'accessories':[],'occlusion':{'foreheadOccluded':false,'eyeOccluded':false,'mouthOccluded':false},'hair':{'bald':0,'invisible':false,'hairColor':[{'color':'brown','confidence':1},{'color':'black','confidence':0.87},{'color':'other','confidence':0.51},{'color':'blond','confidence':0.08},{'color':'red','confidence':0.08},{'color':'gray','confidence':0.02}]}}}]";
    		var Sresponse = JsonConvert.DeserializeObject<List<RootObject>>(json);
    		
    		foreach(var result in Sresponse)
    		{
    			//Get your data here from the deserialization
    		    Console.WriteLine(result.faceId);
    			Console.WriteLine(result.faceRectangle.height);
    			Console.WriteLine(result.faceAttributes.emotion.disgust);			
    		}
    
    	}
    }
    
    public class FaceRectangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    
    public class HeadPose
    {
        public double pitch { get; set; }
        public double roll { get; set; }
        public double yaw { get; set; }
    }
    
    public class FacialHair
    {
        public double moustache { get; set; }
        public double beard { get; set; }
        public double sideburns { get; set; }
    }
    
    public class Emotion
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }
    }
    
    public class Blur
    {
        public string blurLevel { get; set; }
        public double value { get; set; }
    }
    
    public class Exposure
    {
        public string exposureLevel { get; set; }
        public double value { get; set; }
    }
    
    public class Noise
    {
        public string noiseLevel { get; set; }
        public double value { get; set; }
    }
    
    public class Makeup
    {
        public bool eyeMakeup { get; set; }
        public bool lipMakeup { get; set; }
    }
    
    public class Occlusion
    {
        public bool foreheadOccluded { get; set; }
        public bool eyeOccluded { get; set; }
        public bool mouthOccluded { get; set; }
    }
    
    public class HairColor
    {
        public string color { get; set; }
        public double confidence { get; set; }
    }
    
    public class Hair
    {
        public double bald { get; set; }
        public bool invisible { get; set; }
        public List<HairColor> hairColor { get; set; }
    }
    
    public class FaceAttributes
    {
        public double smile { get; set; }
        public HeadPose headPose { get; set; }
        public string gender { get; set; }
        public double age { get; set; }
        public FacialHair facialHair { get; set; }
        public string glasses { get; set; }
        public Emotion emotion { get; set; }
        public Blur blur { get; set; }
        public Exposure exposure { get; set; }
        public Noise noise { get; set; }
        public Makeup makeup { get; set; }
        public List<object> accessories { get; set; }
        public Occlusion occlusion { get; set; }
        public Hair hair { get; set; }
    }
    
    public class RootObject
    {
        public string faceId { get; set; }
        public FaceRectangle faceRectangle { get; set; }
        public FaceAttributes faceAttributes { get; set; }
    }
