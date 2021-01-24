    class Thing
    {
        public string Id { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
        public static Thing FromString(string input)
        {
            var result = new Thing();
            var split = input.Split('~');
            result.Id = split[0];
            foreach (var keyValuePair in split.Skip(1))
            {
                var key = keyValuePair.Substring(0, 3).ToLower();
                if (key == "foo")
                    result.Foo = keyValuePair.Substring(4);
                if (key == "bar")
                    result.Bar = keyValuePair.Substring(4); 
            }
 
            return result;
        }
        public overrides string ToString()
        {
            return $"{Id}~foo={Foo}~bar={Bar}";
        }
    }
