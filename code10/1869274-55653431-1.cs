    public class Weapon
    {
        public int id { get; set; }
        public int status { get; set; }
        public string create_date { get; set; }
        public string update_date { get; set; }
        public string item_id { get; set; }
        public string item_code { get; set; }
        public string image_server { get; set; }
        public string image_url_1 { get; set; }
        public string image_url_2 { get; set; }
        public string image_url_3 { get; set; }
        public string database_name { get; set; }
        public int item_index { get; set; }
        public string sale_status { get; set; }
        public string item_type { get; set; }
        public string item_category1 { get; set; }
        public string item_category2 { get; set; }
        public int item_category3 { get; set; }
        public string display_name { get; set; }
        public string weapon_description { get; set; }
        public int weapon_power { get; set; }
        public int weapon_accuracy { get; set; }
        public int weapon_continuity { get; set; }
        public int weapon_recoil { get; set; }
        public int weapon_weight { get; set; }
        public int weapon_load_ammo { get; set; }
        public int weapon_full_ammo { get; set; }
        public int weapon_range { get; set; }
        public int weapon_angle { get; set; }
        public int add_bullet { get; set; }
        public string special_tag { get; set; }
        public int featured_weapon { get; set; }
        public string duration { get; set; }
        public string location { get; set; }
        public string currency { get; set; }
        public string collection { get; set; }
        public string wdn { get; set; }
    }
    public class Weapons
    {
        [JsonProperty("Weapons")]
        public List<Weapon> WeaponList { get; set; }
    }
    public class RootObject
    {
        public string APIresult { get; set; }
        public string APImessage { get; set; }
        public int Total_Count { get; set; }
        public int Count { get; set; }
        [JsonProperty("Weapons")]
        public Weapons Weapon { get; set; }
    }
