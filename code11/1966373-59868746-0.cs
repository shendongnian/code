    class Record
            {
                public int Option { get; set; }
                public int Year { get; set; }
                public int Month { get; set; }
                public int Value { get; set; }
            }
 
    var resultSet = new List<Record> {
                    new Record { Option=1, Year=2011, Month=12, Value=0   },
                    new Record { Option=1, Year=2011, Month=11, Value=1  },
                    new Record { Option=2, Year=2012, Month=6, Value=0   },
                    new Record { Option=2, Year=2012, Month=7, Value=0   },
                    new Record { Option=1, Year=2011, Month=6, Value=2   },
                };
                
