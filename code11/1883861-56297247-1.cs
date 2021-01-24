    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    
    namespace Jsondemo
    {
        public class Brand
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public string support { get; set; }
            public string url { get; set; }
        }
    
        public class Path
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    
        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public List<Path> path { get; set; }
        }
    
        public class Installment
        {
            public int months { get; set; }
            public int monthlySum { get; set; }
            public double totalAmount { get; set; }
            public double annualInterestRate { get; set; }
            public double interest { get; set; }
            public double fee { get; set; }
        }
    
        public class UiLabels
        {
            public string text { get; set; }
            public string price { get; set; }
            public string time { get; set; }
            public List<string> tooltip { get; set; }
        }
    
        public class Installment2
        {
            public int months { get; set; }
            public string monthlySum { get; set; }
            public double totalAmount { get; set; }
            public double annualInterestRate { get; set; }
            public double interest { get; set; }
            public double fee { get; set; }
        }
    
        public class UiLabels2
        {
            public string text { get; set; }
            public string price { get; set; }
            public string time { get; set; }
            public List<string> tooltip { get; set; }
        }
    
        public class CompanyFinancing
        {
            public List<Installment2> installments { get; set; }
            public UiLabels2 uiLabels { get; set; }
        }
    
        public class Financing
        {
            public List<Installment> installments { get; set; }
            public string type { get; set; }
            public double price { get; set; }
            public UiLabels uiLabels { get; set; }
            public CompanyFinancing companyFinancing { get; set; }
        }
    
        public class Image
        {
            public string __invalid_name__45 { get; set; }
            public string __invalid_name__90 { get; set; }
            public string __invalid_name__300 { get; set; }
            public string __invalid_name__500 { get; set; }
            public string __invalid_name__960 { get; set; }
            public string orig { get; set; }
        }
    
        public class Link
        {
            public string name { get; set; }
            public string type { get; set; }
            public string href { get; set; }
        }
    
        public class Package
        {
            public int width { get; set; }
            public int height { get; set; }
            public int depth { get; set; }
            public int volume { get; set; }
            public int weight { get; set; }
        }
    
        public class Price
        {
            public double current { get; set; }
            public double currentTaxless { get; set; }
            public string currentFormatted { get; set; }
            public double original { get; set; }
            public double originalTaxless { get; set; }
            public string originalFormatted { get; set; }
            public object discountAmount { get; set; }
            public object discountPercentage { get; set; }
            public int taxRate { get; set; }
            public object discount { get; set; }
            public object deposit { get; set; }
            public object unit { get; set; }
        }
    
        public class Rating
        {
            public int reviewCount { get; set; }
            public int averageOverallRating { get; set; }
            public int recommendedCount { get; set; }
        }
    
        public class Relations
        {
            public List<object> recommended { get; set; }
            public List<object> newer { get; set; }
            public List<object> older { get; set; }
            public List<object> bundles { get; set; }
        }
    
        public class Restrictions
        {
            public bool isRestricted { get; set; }
            public List<object> pickupAllowed { get; set; }
            public List<object> postalCodeAllowed { get; set; }
            public string description { get; set; }
            public string descriptionShort { get; set; }
        }
    
        public class ShipmentPrice
        {
            public int id { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public bool pickup { get; set; }
        }
    
        public class Js
        {
            public int stock { get; set; }
            public string stockStatus { get; set; }
        }
    
        public class Pak
        {
            public int stock { get; set; }
            public string stockStatus { get; set; }
        }
    
        public class Vendor
        {
            public int stock { get; set; }
            public string stockStatus { get; set; }
        }
    
        public class Warehouses
        {
            public Js js { get; set; }
            public Pak pak { get; set; }
            public Vendor vendor { get; set; }
        }
    
        public class Web
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
            public Warehouses warehouses { get; set; }
            public string ranking { get; set; }
        }
    
        public class Js2
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class JsKioski
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Oul
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Pir
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Rai
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Pu1
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Pu2
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Pu3
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Pu4
        {
            public bool isAvailable { get; set; }
            public bool isPurchasable { get; set; }
            public int stock { get; set; }
            public string stockStatus { get; set; }
            public int minDays { get; set; }
            public int maxDays { get; set; }
        }
    
        public class Stores
        {
            public Js2 js { get; set; }
            public JsKioski js_kioski { get; set; }
            public Oul oul { get; set; }
            public Pir pir { get; set; }
            public Rai rai { get; set; }
            public Pu1 pu1 { get; set; }
            public Pu2 pu2 { get; set; }
            public Pu3 pu3 { get; set; }
            public Pu4 pu4 { get; set; }
        }
    
        public class Stocks
        {
            public Web web { get; set; }
            public Stores stores { get; set; }
        }
    
        public class Availability
        {
            public string _id { get; set; }
            public int pid { get; set; }
            public object overrideText { get; set; }
            public bool isElectronic { get; set; }
            public bool isVirtual { get; set; }
            public bool isInStoresOnly { get; set; }
            public bool isReleased { get; set; }
            public bool isShippingAllowed { get; set; }
            public bool isPickupAllowed { get; set; }
            public bool isStockVisible { get; set; }
            public bool isPurchasable { get; set; }
            public bool isSoldOut { get; set; }
            public bool isEOL { get; set; }
            public bool isFastDeliveryAvailable { get; set; }
            public bool isStoreOrderAllowed { get; set; }
            public bool hasStock { get; set; }
            public Stocks stocks { get; set; }
            public List<object> tags { get; set; }
            public DateTime updatedAt { get; set; }
            public DateTime verifiedAt { get; set; }
            public int updateCount { get; set; }
            public DateTime updateStartTime { get; set; }
        }
    
        public class RootObject
        {
            public string _id { get; set; }
            public bool active { get; set; }
            public int ageLimit { get; set; }
            public Brand brand { get; set; }
            public List<string> bulletPoints { get; set; }
            public List<object> bundleProducts { get; set; }
            public List<object> campaigns { get; set; }
            public List<string> categories { get; set; }
            public Category category { get; set; }
            public DateTime createdAt { get; set; }
            public List<object> demoLocations { get; set; }
            public string description { get; set; }
            public string descriptionShort { get; set; }
            public List<string> eans { get; set; }
            public bool electronic { get; set; }
            public Financing financing { get; set; }
            public string freeShipmentFor { get; set; }
            public bool hidePriceEstimate { get; set; }
            public string href { get; set; }
            public List<Image> images { get; set; }
            public List<Link> links { get; set; }
            public object maxAmountPerOrder { get; set; }
            public List<string> mpns { get; set; }
            public string name { get; set; }
            public Package package { get; set; }
            public int pid { get; set; }
            public Price price { get; set; }
            public string productId { get; set; }
            public Rating rating { get; set; }
            public Relations relations { get; set; }
            public DateTime releasedAt { get; set; }
            public Restrictions restrictions { get; set; }
            public List<string> ribbons { get; set; }
            public List<ShipmentPrice> shipmentPrices { get; set; }
            public List<object> shopAreas { get; set; }
            public bool vak { get; set; }
            public int visible { get; set; }
            public string warranty { get; set; }
            public DateTime updatedAt { get; set; }
            public DateTime verifiedAt { get; set; }
            public int updateCount { get; set; }
            public DateTime updateStartTime { get; set; }
            public Availability availability { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string API = "https://www.verkkokauppa.com/resp-api/product?pids=552952";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(API);
                request.Method = "GET";
                string result = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    result = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
    
                var jsonresult = JsonConvert.DeserializeObject<List<RootObject>>(result);
    
                foreach (RootObject p in jsonresult)
                {
    
                    Debug.WriteLine(p.brand.name);
                }
                Console.WriteLine("Hello World!");
            }
        }
    }
