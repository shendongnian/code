public class MyModel
{
     [JsonProperty("screen_width")]
     [Required(ErrorMessage = "Required width")]
     [DisplayName("screen_width")]
     public string ScreenWidth { get; set; }  
}
