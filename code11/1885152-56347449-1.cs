    var data =
                "<Team><TeamId>1187457</TeamId><TeamName>Zanardi Redwings</TeamName><Arena><ArenaId>1184019</ArenaId><ArenaName>Evolution</ArenaName></Arena><League><LeagueId>37</LeagueId><LeagueName>România</LeagueName></League><Country><CountryId>36</CountryId><CountryName>România</CountryName></Country><LeagueLevelUnit><LeagueLevelUnitId>4109</LeagueLevelUnitId><LeagueLevelUnitName>V.171</LeagueLevelUnitName></LeagueLevelUnit><Region><RegionId>799</RegionId><RegionName>Prahova</RegionName></Region><YouthTeam><YouthTeamId>2337461</YouthTeamId><YouthTeamName>Little Redwings</YouthTeamName><YouthLeague><YouthLeagueId>436902</YouthLeagueId><YouthLeagueName>Normandie Ligue des jeunes</YouthLeagueName></YouthLeague></YouthTeam></Team>";
            var elm = new XElement("Base",data);
            var decoded = System.Web.HttpUtility.HtmlDecode(elm.ToString());//this is to remove any formatting issues when we call .ToString()
            var doc = XDocument.Parse(decoded);
           
            var result = doc.Root.Descendants("Team")
                .Select(y => new TeamInfo
                {
                    TeamId = Convert.ToInt32(y.Element("TeamId").Value),
                    TeamName = y.Element("TeamName").Value
                }).ToList();
        }
