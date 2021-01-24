    public class Code
    {
        public int[] rgba { get; set; }
        public string rgba_str
        {
            get
            {
                var res = "";
                for(int i = 0; i < rgba.Length; i++) {
                    res += rgba[i] + (i != rgba.Length - 1 ? "," : "");
                }
                return res;
            }
            set
            {
                var strArray = value.Split(',');
                rgba = new int[strArray.Length];
                for(int i = 0; i < strArray.Length; i++) {
                    rgba[i] = int.Parse(strArray[i]);
                }
            }
        }
        public string hex { get; set; }
    }
