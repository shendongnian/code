    public class AccessControlSection : ConfigurationSection
    {
    	public const string SectionName = "accessControl";
    	public const string ForceLockoutKeyName = "forceLockout";
    
    	private static AccessControlSection _settings;
    	public static AccessControlSection Settings {
    		get {
    			if (_settings == null) {
    				object section = ConfigurationManager.GetSection(SectionName);
    				if (section != null)
    					_settings = section as AccessControlSection;
    			}
    			return _settings;
    		}
    	}
    
    	[ConfigurationProperty(ForceLockoutKeyName)]
    	public ForceLockoutElement ForceLockout {
    		get { return (ForceLockoutElement)this[ForceLockoutKeyName]; }
    		set { this[ForceLockoutKeyName] = value; }
    	}
    }
    
    public class ForceLockoutElement : ConfigurationElement
    {
    	public const string AllowRolesKeyName = "allowRoles";
    	public const string AllowUsersKeyName = "allowUsers";
    	public const string DefaultPageKeyName = "defaultPage";
    	public const string EnabledKeyName = "enabled";
    	public const string LogOnUrlKeyName = "logOnUrl";
    	public const string LogOffUrlKeyName = "logOffUrl";
    
    	[ConfigurationProperty(AllowRolesKeyName, DefaultValue = "Admin")]
    	public string AllowRoles {
    		get { return (string)this[AllowRolesKeyName]; }
    		set { this[AllowRolesKeyName] = value; }
    	}
    
    	[ConfigurationProperty(AllowUsersKeyName)]
    	public string AllowUsers {
    		get { return (string)this[AllowUsersKeyName]; }
    		set { this[AllowUsersKeyName] = value; }
    	}
    
    	[ConfigurationProperty(DefaultPageKeyName, DefaultValue = "~/offline.htm")]
    	public string DefaultPage {
    		get { return (string)this[DefaultPageKeyName]; }
    		set { this[DefaultPageKeyName] = value; }
    	}
    
    	[ConfigurationProperty(LogOnUrlKeyName, DefaultValue = "~/auth/logon")]
    	public string LogOnUrl {
    		get { return (string)this[LogOnUrlKeyName]; }
    		set { this[LogOnUrlKeyName] = value; }
    	}
    
    	[ConfigurationProperty(LogOffUrlKeyName, DefaultValue = "~/auth/logoff")]
    	public string LogOffUrl {
    		get { return (string)this[LogOffUrlKeyName]; }
    		set { this[LogOffUrlKeyName] = value; }
    	}
    
    	[ConfigurationProperty(EnabledKeyName, DefaultValue = true)]
    	public bool Enabled {
    		get { return (bool)this[EnabledKeyName]; }
    		set { this[EnabledKeyName] = value; }
    	}
    
    	public string[] AllowedUsersArray {
    		get {
    			if (string.IsNullOrEmpty(AllowUsers))
    				return null;
    
    			return AllowUsers.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
    		}
    	}
    
    	public string[] AllowRolesArray {
    		get {
    			if (string.IsNullOrEmpty(AllowRoles))
    				return null;
    
    			return AllowRoles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    		}
    	}
    }
