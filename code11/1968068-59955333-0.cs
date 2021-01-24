    [Test]
    public void JsonDeserializesTest()
    {
      //WindowsTestApp is namespace of project
      using (Stream stream = Assembly.GetExecutingAssembly().
                             GetManifestResourceStream("WindowsTestApp.Rating.json"))
      using (StreamReader reader = new StreamReader(stream))
      {
          var jsonFileContent = reader.ReadToEnd();
          var jsonData = JsonConvert.DeserializeObject<IList<RatingData>>(jsonFileContent);
          Assert.IsNotNull(jsonData);
      }
      
    }
    //Test class of json data
    public class RatingData
    {
        public int ID { get; set; }
        public int Number { get; set; }
    }
