// In some file, perhaps called Settings.Defaults.cs?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace YourApplication.Properties
{
   internal sealed partial class Settings
   {
      public static SettingsDefaults Defaults
      {
         get { return _defaults; }
      }
      internal class SettingsDefaults
      {
         public int NumberBetween1And100
         {
            get
            {
               // Or just hardcode it and come here and change it if you change the default value.
               return (int)Settings.Default.Properties["NumberBetween1And100"].DefaultValue;
            }
         }
      }
      private static readonly SettingsDefaults _defaults = new SettingsDefaults();
   }
}
You could use it like you described in your question: `Properties.Settings.Defaults.NumberBetween1And100`.
It's not perfect. For example, if you add a new setting from the Settings Designer, you have to remember to come in to this file and add the new property to the `SettingsDefaults` class. Also, `Properties.Settings.Default` and `Properties.Settings.Defaults` are named so similar that it feels likely to be a source of bugs.
