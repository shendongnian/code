    public class Code
    {
        public int[] rgba { get; set; }
        public string rgba_str { 
           get{
              var res = "";
              foreach(int i = 0; i < rgba.Length; i++) {
                 res += rgba[i] + (i != rbga.Length - 1 ? "," : "");
              }
              return res;
           } 
           set{
              var strArray = value.Split(',');
              rgba = new int[strArray.Length];
              foreach(int i = 0; i < strArray.Length; i++) {
                 rgba[i] = int.Parse(srtArray[i]);
              }
           } 
        }
        public string hex { get; set; }
    }
