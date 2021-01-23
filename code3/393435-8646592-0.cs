		<siteMap>
			<providers>
				<add name="anonymous" type="System.Web.XmlSiteMapProvider" siteMapFile="~/YourAnonymouse.sitemap"/>
				<add name="user" type="System.Web.XmlSiteMapProvider" siteMapFile="~/YourNormalUser.sitemap"/>
				<add name="admin" type="System.Web.XmlSiteMapProvider" siteMapFile="~/YourAdmin.sitemap"/>
			</providers>
		</siteMap>
