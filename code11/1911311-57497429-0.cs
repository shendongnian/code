    [Table("Computer")]
    public class Computer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public string Port { get; set; }
        public bool Selected { get; set; }
        [Ignore]
        public string Selected_Color
        {
            get
            {
                string Text_Color = string.Empty;
                try
                {
                    if (Selected == true)
                    {
                        //Green color
                        Text_Color = "#33cc33";
                    }
                    else
                    {
                        Text_Color = "#000000";
                    }
                }
                catch (Exception ex)
                {
                    return "#000000";
                }
                return Text_Color;
            }
        }
    }
