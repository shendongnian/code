    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Resources;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count < 1)
            {
                var installedCultures = GetInstalledCultures();
                IEnumerable<ListItem> listItems = installedCultures.Select(cultInfo =>
                    new ListItem(Resource.ResourceManager.GetString("LanguageName", cultInfo), cultInfo.Name));
                ListBox1.Items.AddRange(listItems.ToArray());
            }
        }
        public IEnumerable<CultureInfo> GetInstalledCultures()
        {
            foreach (string file in Directory.GetFiles(Server.MapPath("~/App_GlobalResources"), "*.resx"))
            {
                if (!file.EndsWith(".resx"))
                    continue;
                var endCropPos = file.Length - ".resx".Length;
                var beginCropPos = file.LastIndexOf(".", endCropPos - 1) + 1;
                string culture = "en";
                if (beginCropPos > 0 && file.LastIndexOf("\\") < beginCropPos)
                    culture = file.Substring(beginCropPos, endCropPos - beginCropPos);
                yield return new CultureInfo(culture);
            }
        }
        // override to set the Culture with the ListBox1 (use AutoPostBack="True")
        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            
            var cult = Request["ctl00$MainContent$ListBox1"];
            if (cult != null)
            {
                Culture = cult;
                UICulture = cult;
            }
        }
    }
