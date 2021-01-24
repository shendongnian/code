bool client = clientGroupImage == "/Content/Images/ClientLogoDefault.svg";
bool site = site.ImageURL == "/Content/Images/ClientSiteLogoDefault.svg";
if (!string.IsNullOrEmpty(site.ImageURL) && (!client && !site || client && !site)
{
   model.SiteLogoURL = site.ImageURL;
}
else if (!client && (site || site.ImageURL == "")
{
   model.SiteLogoURL = clientGroupImage;
}
else
{
   model.SiteLogoURL = "/Content/Images/ClientSiteLogoDefault.svg";
}
