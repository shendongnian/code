    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Configuration;
    using System.Xml;
    
    public class AppConfigFileSettings
    {
    
    
    	public static void UpdateAppSettings(string KeyName, string KeyValue)
    	{
    		XmlDocument XmlDoc = new XmlDocument();
    
    		XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    
    		foreach (XmlElement xElement in XmlDoc.DocumentElement) {
    			if (xElement.Name == "appSettings") {
    
    				foreach (XmlNode xNode in xElement.ChildNodes) {
    					if (xNode.Attributes[0].Value == KeyName) {
    						xNode.Attributes[1].Value = KeyValue;
    					}
    				}
    			}
    		}
    		XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    	}
    }
