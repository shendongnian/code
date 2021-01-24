    @using WEKA.Models
    @using Microsoft.AspNetCore.Html
    <div class="jobs-list">
        @foreach (var e in News)
        {
            <div class="job" data-aos="fade-up">
                <a href="@e.Link">
                    <div class="col name">@e.Text</div>
                    <div class="col more">Detail</div>
                </a>
            </div>
        }
    </div>
    @code {
        public List<QNewsList> News
        {
            set { }
            get
            {
                using (WEKAContext db = new WEKAContext())
                {
                    var q = from n in db.Qaktuality select new QNewsList() { Datum = n.Datum.ToString("d.M.YYYY"), Text = new MarkupString(n.Text), Link = n.RssLink };
                    return q.ToList();
                }
            }
        }
        public class QNewsList
        {
            public string Datum;
            public MarkupString Text;
            public string Link;
        }
    }
