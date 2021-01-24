            var sec = _tfs.GetService<IGroupSecurityService>();
            var vcs = _tfs.GetService<VersionControlServer>();
            Identity[] appGroups = sec.ListApplicationGroups(vcs.GetTeamProject(_selectedTeamProject).ArtifactUri.AbsoluteUri);
            foreach (Identity group in appGroups)
            {
                Identity[] groupMembers = sec.ReadIdentities(SearchFactor.Sid, new string[] { group.Sid }, QueryMembership.Expanded);
                foreach (Identity member in groupMembers)
                {
                    if (member.Members != null)
                    {
                        foreach (string memberSid in member.Members)
                        {
                            Identity memberInfo = sec.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.Expanded);
                            if (memberInfo.DisplayName.ToUpper() == "Patrick Lu")
                            {
                                memberInfo.DisplayName = "Test User ";
                            }
                        }
                    }
                }
            }
