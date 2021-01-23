         string strTextToReplace = "<tr><td style=\"height: 80px; background-color:#F4FAFF\"> <span class=\"testPropertiesTitle\">Test Properties</span><br /><br /><span class=\"headerComment\"><b>Test Mode:</b>&nbsp;[TestMode]</span><br /><br /><span class=\"headerComment\"><b>Referenced DUT:</b>&nbsp;[RefDUT]</span><br/><br/><span class=\"headerComment\"><b>Voltage Failure Limit:</b>&nbsp;[VoltageLimit]</span><br /><br /><span class=\"headerComment\"><b>Current Failure Limit:</b>&nbsp;[CurrentLimit]</span><br /><br /><span class=\"headerComment\"><b>Test Mode:</b>[TestMode]&nbsp;</span>  </td></tr>";
    
                Regex re = new Regex(@"\[(.*?)\]");
                MatchCollection mc = re.Matches(strTextToReplace);
                foreach (Match m in mc)
                {
                    switch (m.Value)
                    {
                        case "[TestMode]":
                            strTextToReplace = strTextToReplace.Replace(m.Value, "-- New Test Mode --");
                            break;
                        case "[RefDUT]":
                            strTextToReplace = strTextToReplace.Replace(m.Value, "-- New Ref DUT --");
                            break;
                        //Add additional CASE statements here
                        default:
                            break;
                    }
                }
