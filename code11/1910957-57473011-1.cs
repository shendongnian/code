    void Main()
    {
    	string json = "{\"UserName\":\"xyz\",\"UserNotifications\":{\"Email\":\"\",\"SMS\":\"\",\"Push_Messages\":\"\"}}";
    	
    	var result  = JsonConvert.DeserializeObject<UserSetting>(json);
    	
    	result.Dump();
    }
    
    // Create a Custom JsonConverter
    public class UserNotificationsConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(UserNotifications).IsAssignableFrom(objectType);
    	}
        
        // Custom logic in the ReadJson
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    			var userNotificationObj = serializer.Deserialize<UserNotifications>(reader);
    			
    			userNotificationObj.Email = string.IsNullOrEmpty(userNotificationObj.Email) ? "false" : userNotificationObj.Email;
    			userNotificationObj.SMS = string.IsNullOrEmpty(userNotificationObj.SMS) ? "false" : userNotificationObj.SMS;
    			userNotificationObj.Push_Messages = string.IsNullOrEmpty(userNotificationObj.Push_Messages) ? "false" : userNotificationObj.Push_Messages;
    			
    			return userNotificationObj;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
    
    // UserSetting entity
    public class UserSetting
    {
    	public string UserName {get; set;}
    	
        // Decorate with the Custom Json Converter
    	[JsonConverterAttribute(typeof(UserNotificationsConverter))]
    	public UserNotifications UserNotifications {get; set;}
    }
    
    public class UserNotifications
    {
    	public string Email {get; set;}
    	
    	public string SMS {get; set;}
    	
    	public string Push_Messages {get; set;}
    }
