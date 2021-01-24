    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    
    [TestFixture]
    public class PermutatorTest
    {
        private IList<Section> _sections;
        private int _targetPage;
        private IList<Config> _result;
        [SetUp]
        public void SetUp()
        {
            _targetPage = 30;
            _sections = new List<Section>
            {
                new Section {Id = 1, Pages = 15, Name = "A"},
                new Section {Id = 2, Pages = 15, Name = "B"},
                new Section {Id = 3, Pages = 10, Name = "C" },
                new Section {Id = 4, Pages = 10, Name = "D"},
                new Section {Id = 5, Pages = 10, Name = "E"},
                new Section {Id = 6, Pages = 5, Name = "F"}
            };
    
            _result = new List<Config>();
        }
    
        [Test]
        public void GetPermutationsTest()
        {
    
            for (var b =0 ; b<=_sections.Count-1; b++)
            {
                var config = new Config
                {
                    Name = _sections[b].Name,
                    Ids =  _sections[b].Id.ToString(),
                    Pages = _sections[b].Pages
                };
                GoDeeperAndAddToResult(config, b);
            }
    
            Console.WriteLine(_result.Count);
    
            foreach (var item in _result)
            {
                Console.WriteLine($"{item.Name} - {item.Ids} - {item.Pages}");
            }
        }
    
        private void GoDeeperAndAddToResult(Config config, int startIndex)
        {
            for (var b = startIndex; b <= _sections.Count-1; b++)
            {
                var section = _sections[b];
    
                var combName = config.Name;
                var combIds = config.Ids;
                var combPages = config.Pages;
    
                var maxSec = _targetPage / section.Pages;
                for (var a = 1; a <= maxSec; a++)
                {
                    combName = combName + section.Name;
                    combIds = combIds + section.Id.ToString();
                    combPages = combPages + section.Pages;
    
                    var subConfig = new Config
                    {
                        Name = combName,
                        Ids = combIds,
                        Pages = combPages
                    };
    
                    if (subConfig.Pages == _targetPage)
                    {
                        _result.Add(subConfig);
                        break;
                    }
                    else if (subConfig.Pages < _targetPage)
                    {
                        GoDeeperAndAddToResult(subConfig, b + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    
        public class Config
        {
            public string Name { get; set; }
            public string Ids { get; set; }
            public int Pages { get; set; }
        }
    
        public class Section
        {
            public int Id { get; set; }
            public int Pages { get; set; }
            public string Name { get; set; }
        }
    }
