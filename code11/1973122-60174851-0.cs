                List<Step> list = new List<Step>();
                var distinctSteps = list
                                   .Where(s => !string.IsNullOrWhiteSpace(s.StepId))
                                   .Distinct();
            }
        }
        public class Step
        {
            public string WorkId { get; set; }
            public string StepId { get; set; }
            public string Name { get; set; }
        }
