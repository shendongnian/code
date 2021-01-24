    var ans = data.Select(d => new AnsClass {
                        PropA = d.PropA,
                        PropB = d.PropB,
                        PropC = d.PropC,
                        PropD11 = d.PropD.Values.FirstOrDefault(v => v.Name == "PropD11")?.Value,
                        PropD12 = d.PropD.Values.FirstOrDefault(v => v.Name == "PropD12")?.Value,
                        PropD21 = d.PropD.Values.FirstOrDefault(v => v.Name == "PropD21")?.Value,
                        PropD22 = d.PropD.Values.FirstOrDefault(v => v.Name == "PropD22")?.Value,
                    })
                    .ToList();
