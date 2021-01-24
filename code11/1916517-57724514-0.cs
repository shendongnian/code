    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"[{'ImageUrl':'URL','ImageModeration':{'CacheID':'396a972f-79ae-4b31-a54c-0ba3314318fa_637026883058218816','Result':false,'TrackingId':'UKS_ibiza_464a60be-f57d-4ee1-aa37-13d04f151fdd_ContentModerator.F0_4ae15371-36c9-4cb2-8e21-83381a29432c','AdultClassificationScore':0.004845567513257265,'IsImageAdultClassified':false,'RacyClassificationScore':0.011258091777563095,'IsImageRacyClassified':false,'AdvancedInfo':[{'Key':'ImageDownloadTimeInMs','Value':'37'},{'Key':'ImageSizeInBytes','Value':'34854'}],'Status':{'Code':3000,'Description':'OK','Exception':null}},'TextDetection':null,'FaceDetection':null}]";
    		var Sresponse = JsonConvert.DeserializeObject<List<RootObject>>(json);
    		
    		foreach(var value1 in Sresponse)
    		{
    		  Console.WriteLine(value1.ImageUrl);
    		  Console.WriteLine(value1.ImageModeration.CacheID);	
    		}
    	}
    }
    
    public class AdvancedInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    
    public class Status
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public object Exception { get; set; }
    }
    
    public class ImageModeration
    {
        public string CacheID { get; set; }
        public bool Result { get; set; }
        public string TrackingId { get; set; }
        public double AdultClassificationScore { get; set; }
        public bool IsImageAdultClassified { get; set; }
        public double RacyClassificationScore { get; set; }
        public bool IsImageRacyClassified { get; set; }
        public List<AdvancedInfo> AdvancedInfo { get; set; }
        public Status Status { get; set; }
    }
    
    public class RootObject
    {
        public string ImageUrl { get; set; }
        public ImageModeration ImageModeration { get; set; }
        public object TextDetection { get; set; }
        public object FaceDetection { get; set; }
    }
