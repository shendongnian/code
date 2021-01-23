    public class StackOverflow_6747339
    {
        class FacetsAsSiblingOfHints
        {
            [DataContract]
            public class AutoCompleteResponse
            {
                [DataMember(Name = "parameters")]
                public Parameter Parameters { get; set; }
                [DataMember(Name = "termHints")]
                public List<TermHints> Hints { get; set; }
                [DataMember(Name = "facets")]
                public List<Facets> Facets { get; set; }
                [DataMember(Name = "total")]
                public string Total { get; set; }
                public override string ToString()
                {
                    return string.Format("AutoCompleteResponse[Parameters={0},hints={1},facets={2},total={3}]",
                        Parameters, ListToString(Hints), ListToString(Facets), Total);
                }
            }
            [DataContract]
            public class Parameter
            {
                [DataMember(Name = "tbdb")]
                public string tbdb { get; set; }
                [DataMember(Name = "min_prefix_length")]
                public string min_prefix_length { get; set; }
                [DataMember(Name = "service")]
                public string service { get; set; }
                [DataMember(Name = "template")]
                public string template { get; set; }
                [DataMember(Name = "term_prefix")]
                public string term_prefrix { get; set; }
                public override string ToString()
                {
                    return string.Format("Parameter[tbdb={0},min_prefix_length={1},service={2},template={3},term_prefix={4}]",
                        tbdb, min_prefix_length, service, template, term_prefrix);
                }
            }
            [DataContract]
            public class TermHints
            {
                [DataMember(Name = "name")]
                public string Name { get; set; }
                [DataMember(Name = "id")]
                public string Id { get; set; }
                [DataMember(Name = "values")]
                public Values Values { get; set; }
                public override string ToString()
                {
                    return string.Format("TermHints[Name={0},Id={1},Values={2}]", Name, Id, Values);
                }
            }
            [DataContract]
            public class Values
            {
                [DataMember(Name = "value")]
                public string value_name { get; set; }
                [DataMember(Name = "pre_em")]
                public string pre_em { get; set; }
                [DataMember(Name = "em")]
                public string em { get; set; }
                [DataMember(Name = "post_em")]
                public string post_em { get; set; }
                [DataMember(Name = "nature")]
                public string nature { get; set; }
                [DataMember(Name = "id")]
                public string value_id { get; set; }
                public override string ToString()
                {
                    return string.Format("Values[value_name={0},pre_em={1},em={2},post_em={3},nature={4},value_id={5}]",
                        value_name, pre_em, em, post_em, nature, value_id);
                }
            }
            [DataContract]
            public class Facets
            {
                [DataMember(Name = "id")]
                public string facet_id { get; set; }
                [DataMember(Name = "name")]
                public string facet_name { get; set; }
                public override string ToString()
                {
                    return string.Format("Facets[facet_id={0},facet_name={1}]", facet_id, facet_name);
                }
            }
            const string json = @"{
    ""parameters"": {
        ""tbdb"": ""trudon"",
        ""min_prefix_length"": ""2"",
        ""service"": ""prefix"",
        ""template"": ""service.json"",
        ""term_prefix"": ""plu""},
    ""termHints"": [
        {
            ""name"": ""Plumbers & Sanitary Engineers"",
            ""id"":""209654"",
            ""values"": {
                ""value"":""Plumbers & Sanitary Engineers"",
                ""pre_em"":"""",
                ""em"":""Plu"",
                ""post_em"":""mbers & Sanitary Engineers"",
                ""nature"":""PT"",
                ""id"":""209654""
            }
        },
    ],
    ""facets"": [
        {
            ""id"":""209654"",
            ""name"":""Plumbers & Sanitary Engineers""
        }
    ],
    ""total"":1
    }";
            internal static void Test()
            {
                Console.WriteLine("Facets as siblings of the hints");
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(AutoCompleteResponse));
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                AutoCompleteResponse obj = (AutoCompleteResponse)dcjs.ReadObject(ms);
                ms.Close();
                Console.WriteLine(obj);
                Console.WriteLine();
            }
        }
        class FacetsInsideHints
        {
            [DataContract]
            public class AutoCompleteResponse
            {
                [DataMember(Name = "parameters")]
                public Parameter Parameters { get; set; }
                [DataMember(Name = "termHints")]
                public List<TermHints> Hints { get; set; }
                [DataMember(Name = "total")]
                public string Total { get; set; }
                public override string ToString()
                {
                    return string.Format("AutoCompleteResponse[Parameters={0},hints={1},total={2}]",
                        Parameters, ListToString(Hints), Total);
                }
            }
            [DataContract]
            public class Parameter
            {
                [DataMember(Name = "tbdb")]
                public string tbdb { get; set; }
                [DataMember(Name = "min_prefix_length")]
                public string min_prefix_length { get; set; }
                [DataMember(Name = "service")]
                public string service { get; set; }
                [DataMember(Name = "template")]
                public string template { get; set; }
                [DataMember(Name = "term_prefix")]
                public string term_prefrix { get; set; }
                public override string ToString()
                {
                    return string.Format("Parameter[tbdb={0},min_prefix_length={1},service={2},template={3},term_prefix={4}]",
                        tbdb, min_prefix_length, service, template, term_prefrix);
                }
            }
            [DataContract]
            public class TermHints
            {
                [DataMember(Name = "name")]
                public string Name { get; set; }
                [DataMember(Name = "id")]
                public string Id { get; set; }
                [DataMember(Name = "values")]
                public Values Values { get; set; }
                [DataMember(Name = "facets")]
                public List<Facets> Facets { get; set; }
                public override string ToString()
                {
                    return string.Format("TermHints[Name={0},Id={1},Values={2},Facets={3}]", Name, Id, Values, ListToString(Facets));
                }
            }
            [DataContract]
            public class Values
            {
                [DataMember(Name = "value")]
                public string value_name { get; set; }
                [DataMember(Name = "pre_em")]
                public string pre_em { get; set; }
                [DataMember(Name = "em")]
                public string em { get; set; }
                [DataMember(Name = "post_em")]
                public string post_em { get; set; }
                [DataMember(Name = "nature")]
                public string nature { get; set; }
                [DataMember(Name = "id")]
                public string value_id { get; set; }
                public override string ToString()
                {
                    return string.Format("Values[value_name={0},pre_em={1},em={2},post_em={3},nature={4},value_id={5}]",
                        value_name, pre_em, em, post_em, nature, value_id);
                }
            }
            [DataContract]
            public class Facets
            {
                [DataMember(Name = "id")]
                public string facet_id { get; set; }
                [DataMember(Name = "name")]
                public string facet_name { get; set; }
                public override string ToString()
                {
                    return string.Format("Facets[facet_id={0},facet_name={1}]", facet_id, facet_name);
                }
            }
            const string json = @"{
    ""parameters"": {
        ""tbdb"": ""trudon"",
        ""min_prefix_length"": ""2"",
        ""service"": ""prefix"",
        ""template"": ""service.json"",
        ""term_prefix"": ""plu""},
    ""termHints"": [
        {
            ""name"": ""Plumbers & Sanitary Engineers"",
            ""id"":""209654"",
            ""values"": {
                ""value"":""Plumbers & Sanitary Engineers"",
                ""pre_em"":"""",
                ""em"":""Plu"",
                ""post_em"":""mbers & Sanitary Engineers"",
                ""nature"":""PT"",
                ""id"":""209654""
            },
            ""facets"": [
                {
                    ""id"":""209654"",
                    ""name"":""Plumbers & Sanitary Engineers""
                }
            ]
        },
    ],
    ""total"":1
    }";
            internal static void Test()
            {
                Console.WriteLine("Facets inside the hints");
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(AutoCompleteResponse));
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                AutoCompleteResponse obj = (AutoCompleteResponse)dcjs.ReadObject(ms);
                ms.Close();
                Console.WriteLine(obj);
                Console.WriteLine();
            }
        }
        static string ListToString<T>(List<T> list)
        {
            if (list == null)
            {
                return "<<null>>";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append(list[i]);
            }
            sb.Append("]");
            return sb.ToString();
        }
        public static void Test()
        {
            FacetsAsSiblingOfHints.Test();
            FacetsInsideHints.Test();
        }
    }
