    public  double FindMaxHeight(List<SiteData> objSite)
    		{
    			objSite.Sort(new Comparison<SiteData>((x, y)
    				=>
    				{
    					int xHeight, yHeight;
    					yHeight = y.SiteHeight.HasValue ? y.SiteHeight.Value : 0;
    					xHeight = x.SiteHeight.HasValue ? x.SiteHeight.Value : 0;
    					return yHeight.CompareTo(xHeight);
    				}
    			));
    			return  objSite.Count > 0 ?  objSite[0].SiteHeight.Value : 0;
    		}
