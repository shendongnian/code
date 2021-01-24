json
{
    "id": "bird",
    "metadata": {
        "operation": "retrieve",
        "provider": "Oxford University Press",
        "schema": "RetrieveEntry"
    },
    "results": [
        {
            "id": "bird",
            "language": "en-gb",
            "lexicalEntries": [
                {
                    "entries": [
                        {
                            "senses": [
                                {
                                    "definitions": [
                                        "a warm-blooded egg-laying vertebrate animal distinguished by the possession of feathers, wings, a beak, and typically by being able to fly."
                                    ],
                                    "id": "m_en_gbus0097360.006",
                                    "subsenses": []
                                },
                                {
                                    "definitions": [
                                        "a person of a specified kind or character"
                                    ],
                                    "id": "m_en_gbus0097360.014"
                                },
                                {
                                    "definitions": [
                                        "a young woman or a girlfriend."
                                    ],
                                    "id": "m_en_gbus0097360.016"
                                }
                            ]
                        }
                    ],
                    "language": "en-gb",
                    "lexicalCategory": {
                        "id": "noun",
                        "text": "Noun"
                    },
                    "text": "bird"
                }
            ],
            "type": "headword",
            "word": "bird"
        }
    ],
    "word": "bird"
}
2) The collections should be initialized in the class definitions, e.g.:
c#
class WordDefinition
{
    public RootObject rootObject { get; set; }
    public Metadata metadata { get; set; }
    public List<Result> results { get; set; } = new List<Result>();
    public List<LexicalEntry> lexicalEntries { get; set; } = new List<LexicalEntry>();
    public List<Entry> entries { get; set; } = new List<Entry>();
    public List<Sens> senses { get; set; } = new List<Sens>();
    public List<Subsens> subsenses { get; set; } = new List<Subsens>();
    public LexicalCategory lexicalCategory { get; set; }
    public class Metadata
    {
        public string operation { get; set; }
        public string provider { get; set; }
        public string schema { get; set; }
    }
    public class Subsens
    {
        public List<string> definitions { get; set; } = new List<string>();
        public string id { get; set; }
    }
    public class Sens
    {
        public List<string> definitions { get; set; } = new List<string>();
        public string id { get; set; }
        public List<Subsens> subsenses { get; set; } = new List<Subsens>();
    }
    public class Entry
    {
        public List<Sens> senses { get; set; } = new List<Sens>();
    }
    public class LexicalCategory
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    public class LexicalEntry
    {
        public List<Entry> entries { get; set; } = new List<Entry>();
        public string language { get; set; }
        public LexicalCategory lexicalCategory { get; set; }
        public string text { get; set; }
    }
    public class Result
    {
        public string id { get; set; }
        public string language { get; set; }
        public List<LexicalEntry> lexicalEntries { get; set; } = new List<LexicalEntry>();
        public string type { get; set; }
        public string word { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public Metadata metadata { get; set; }
        public List<Result> results { get; set; } = new List<Result>();
        public string word { get; set; }
    }
}
And 3) The JSON doesn't have a `senses` element at the root level. Maybe you intended `test.results[0].lexicalEntries[0].entries[0].senses` instead? e.g.:
c#
var test = JsonConvert.DeserializeObject<WordDefinition>(jsonResponse);
foreach (var testing in test.results[0].lexicalEntries[0].entries[0].senses)
{
    MessageBox.Show(testing.definitions[0].ToString());
}
