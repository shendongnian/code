                DataClass myData = new DataClass()
                {
                    num = 13,
                    code = "message",
                    part = new PartClass()
                    {
                        seriesNum = 1,
                        //here down nothing works; error
                        seriesCode = "abc"
                    },
                    member = new MemberClass()
                    {
                        versionNum = 9,
                        side = new Side()
                        {
                            firstDetail = "pass",
                            secondDetail = "checked",
                            include = true
                        }
                    }
                };
