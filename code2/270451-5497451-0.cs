    Action<XElement, String> ParseXMLInfo = (s, t) => {
                var Records = s.Elements ("record");
                Parallel.ForEach (
                    ParallelEnumerable.Range (0, Records.Count ()),
                    () => new Testing_And_Benchmarking_Entities (),
                    (u, L, v) => {
                        var el = Records.ElementAt (u);
                        var NTR = new tbl_UserInfo ();
                        NTR.first_name = el.Element ("first_name").Value;
                        NTR.last_name = el.Element ("last_name").Value;
                        v.AddTotbl_UserInfo (NTR);
                        return v;
                    },
                    (v) => v.SaveChanges ()
                );
            };
            Parallel.Invoke (
                () => {
                    var XMLDoc_MaleInfo = XElement.Load ("MaleNames.xml");
                    Console.WriteLine ("Fetching records from MaleNames.xml; starting at " + System.DateTime.Now);
                    ParseXMLInfo (XMLDoc_MaleInfo, "male");
                },
                () => {
                    var XMLDoc_FemaleInfo = XElement.Load ("FemaleNames.xml");
                    Console.WriteLine ("Fetching records from MaleNames.xml; starting at " + System.DateTime.Now);
                    ParseXMLInfo (XMLDoc_FemaleInfo, "female");
                }
            );
