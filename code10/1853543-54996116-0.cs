    public class MyText
    {
        [Key]
        public int Id { get; set; }
   
        //leaving this blank it will give you nvarchar(MAX)
        public string Txt { get; set; }
    }
