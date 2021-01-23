     public static string GetChecksum(this YourClass obj)
        {
            var copy = new
            {
               obj.Prop1,
               obj.Prop2
            };
            var json = JsonConvert.SerializeObject(ob);
            return json.CalculateMD5Hash();
        }
