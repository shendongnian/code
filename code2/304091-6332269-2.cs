    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string YourHtmlStringWithPlaceholders = "Aenean {Image, picture.jpg, Centre, Picture Info} non felis at est gravida tincidunt. {Link, news.bbc.co.uk, popup, 500, 800} Donec non diam a mauris vestibulum condimentum eu vitae mi! Aenean sed elit libero, id mollis felis! {Image, ServiceTile.jpg, Left}";
    
                Regex PlaceholderExpander = new Regex(@"\{Image, ([^,]+), ([^,]+)(?:, ([^}]+))?\}");
                string Expanded = PlaceholderExpander.Replace(YourHtmlStringWithPlaceholders,"<img src='$1' alt='$3' class='quipImg$2'></img>");
    
                Console.WriteLine(Expanded);    
            }
        }
    }
