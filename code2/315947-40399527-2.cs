    using System;
    using System.Collections.Generic;
    using System.Web;
    using Newtonsoft.Json;
    public class Customer
    {
        public int id;
        public string name;
    }
    public class Order
    {
        public int id;
        public decimal total;
        public Customer customer;
    }
    public class OrderItem
    {
        public int id;
        public string name;
        public decimal price;
    }
    public class Buy
    {
        public Order order;
        public List<OrderItem> cart;
    }
    static readonly string cookieName = @"buy";
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
            Restore_Click(null, null);
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        string buy = JsonConvert.SerializeObject(new
        {
            order = new
            {
                id = 1,
                total = 20.10,
                customer = new
                {
                    id = 1,
                    name = "Stackoverflow"
                }
            },
            cart = new[] {
                new {
                    id = 1 , 
                    name = "Stack",
                    price = 10.05 
                },
                new {
                    id = 2 , 
                    name = "Overflow",
                    price = 10.05 
                }
            }
        });
        HttpContext.Current.Response.Cookies.Add(
            new HttpCookie(cookieName, buy) {
                Expires = DateTime.Now.AddDays(7)
            }
        );
        StatusLabel.Text = "Saved";
    }
    protected void Prolong_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Add(cookie);
            StatusLabel.Text = "Prolonged";
        }
        else StatusLabel.Text = "Not prolonged - expired";
    }
    protected void Restore_Click(object sender, EventArgs e)
    {
        Buy buy = null;
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        {
            buy = JsonConvert.DeserializeObject<Buy>(cookie.Value);
            StatusLabel.Text = "Restored";
        }
        else StatusLabel.Text = "Not restored - expired";
    }
    protected void ClearOut_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddMonths(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            StatusLabel.Text = "Cleared out";
        }
        else StatusLabel.Text = "Not found - expired";
    }
