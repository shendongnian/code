            dynamic o = new ExpandoObject();
            o.Time = "11:33";
            var n = Newtonsoft.Json.JsonConvert.SerializeObject(o);
            dynamic oa = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(n);
            Console.Write(oa.Time);
            Console.Read();
