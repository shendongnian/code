            if (!IsPostBack)
            {
                this.MasterPageFile = "../../04.07.ManifestoKontrol.Web/ManifestoKontrolMasterPage.master";
                Session[String.Concat(DefaultMasterPageSessionVariableName, this.ClientID)] = this.Master.AppRelativeVirtualPath;
                base.OnPreInit(e);
            }
            else
            {
                if (Session[String.Concat(DefaultMasterPageSessionVariableName, this.ClientID)] != null)
                    this.MasterPageFile = Session[String.Concat(DefaultMasterPageSessionVariableName, this.ClientID)].ToString();
            }
        }
