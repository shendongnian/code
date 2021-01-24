        public class tagNoMatchClass
        {
            public string tag { get; set; }
            public string col { get; set; }
        }
        public class Test
        {
            List<string> tagNoMatchList = new List<string>();
            List<tagNoMatchClass> tagNoMatchList2;
            public Test()
            {
                tagNoMatchList2 = new List<tagNoMatchClass>();
                tagNoMatchList.Add("</Configuration>");
                tagNoMatchList.Add("<SWCheck>");
                tagNoMatchList.Add("</SWCheck>");
                
                tagNoMatchList2.Add(new tagNoMatchClass() {  col = "A29", tag = "</Configuration>"});
                tagNoMatchList2.Add(new tagNoMatchClass() {col = "A52", tag = "</SWCheck>"});
            
                bool test =   tagNoMatchList2.Any(x => x.tag == tagNoMatchList[0]);
            }
        }
