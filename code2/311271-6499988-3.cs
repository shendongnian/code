    public static int UpdateSegment(int segmentId)
            {
                Table<ContactViewItem> Contacts;
                var  conditionsFormatted = new Dictionary<string, string>();
    
                //Retrieve all conditions
                var segmentConditions = Lists.GetSegmentConditions(segmentId);
    
                //Iterate through conditions and process them
                foreach (var condition in segmentConditions)
                {
                    switch (condition.Operator)
                    {
                        case SegmentCondition.OperatorType.Equals:
                            condition.Condition =  string.Format("{1}=\"{0}\"", condition.Criteria, condition.Field);
                            break;
                        case SegmentCondition.OperatorType.Contains:
                            condition.Condition = string.Format("{1}.Contains(\"{0}\")", condition.Criteria, condition.Field);
                            break;
                        default:
                            throw new ApplicationException("Unexpected Operator for Condition");
                    }
                }
    
    
                var db = new DbContext(ConfigurationManager.ConnectionStrings["c"].ConnectionString);
    
                var statusConditions = "Status = 1";
    
                var results = (IQueryable)db.Contacts.Where(statusConditions);
    
                var distinctFields = (from c in segmentConditions select c.Field).Distinct();
    
                foreach (var distinctField in distinctFields)
                {
                    var values = (from s in segmentConditions where s.Field == distinctField select s.Condition).ToArray();
                    var valuesJoined = string.Join("||", values);
                    results = results.Where(valuesJoined);
    
                }
    
                results = results.Select("id");
    
    
                var xml = new StringBuilder();
                xml.Append("<Ids>");
    
                foreach (var id in results)
                {
                    xml.Append(String.Format("<Id>{0}</Id>", id));
                }
                xml.Append("</Ids>");
    
                var idXml = XDocument.Parse(xml.ToString());
    
                return Lists.UpdateSegmentContacts(idXml.ToString(), segmentId);
    
            }
