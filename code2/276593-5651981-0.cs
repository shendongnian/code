    protected void Page_Load(object sender, EventArgs e) {
      string conn = GetConnectionString();
      if (String.IsNullOrEmpty(conn)) {
        Console.WriteLine("No Connection String!");
        return;
      }
      try {
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        SqlCommand cmd = new SqlCommand("DisplayCustomerReviews", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        XmlReader reader = cmd.ExecuteXmlReader();
        while (!reader.EOF) {
          reader.ReadToFollowing("review");
          reader.MoveToAttribute("Name");
          string Name = reader.Value;
          reader.MoveToAttribute("Message");
          string Message = reader.Value;
          reader.MoveToAttribute("Rating");
          string Rating = reader.Value;
          reader.MoveToAttribute("Date");
          string Date = reader.Value;
          reader.MoveToAttribute("Time");
          string Time = reader.Value;
          CreateReviewPanel(Name, Message, Rating, Date, Time);
        }
        reader.Close();
        connection.Close();
      } catch (Exception err) {
        Console.WriteLine("Possible Problems:");
        Console.WriteLine("DisplayCustomerReviews was not found or spelled incorrectly");
        Console.WriteLine("One or more of the attributes listed above do not exist.");
        Console.WriteLine(err.Message);
      }
    }
    private string GetConnectionString() {
      string connStr = null;
      try {
        connStr = ConfigurationManager.AppSettings["SQLConn"];
      } catch (Exception err) {
        Console.WriteLine("AppSettings is incorrect or does not contain SQLConn");
        Console.WriteLine(err.Message);
      }
      return connStr;
    }
    private void CreateReviewPanel(string Name, string Message, string Rating, string Date, string Time) {
      if (!String.IsNullOrEmpty(Name)) //need to check against nulls or empty strings to avoid extra reviewPanel being created at end of XML read.
      {
        Guid panelID = Guid.NewGuid();
        Panel reviewPanel = new Panel();
        try {
          reviewPanel.ID = panelID.ToString();
        } catch (Exception) {
          Console.WriteLine("Panel Object does not contain an ID property.");
          Console.WriteLine(err.Message);
        }
        nameLabel.Text = Name;
        messageLabel.Text = Message;
        dateLabel.Text = Date;
        timeLabel.Text = Time;
        try {
          switch (Rating) {
            case "1":
              ratingImage.ImageUrl = "~/images/one-star.gif";
              break;
            case "2":
              ratingImage.ImageUrl = "~/images/two-stars.gif";
              break;
            case "3":
              ratingImage.ImageUrl = "~/images/three-stars.gif";
              break;
            case "4":
              ratingImage.ImageUrl = "~/images/four-stars.gif";
              break;
            case "5":
              ratingImage.ImageUrl = "~/images/five-stars.gif";
              break;
          }
          Console.WriteLine("File Check: ", ratingImage.ImageUrl);
          Console.WriteLine(File.Exists(ratingImage.ImageUrl));
        } catch (Exception err) {
          Console.WriteLine("This control type does not contain an ImageUrl property");
          Console.WriteLine(err.Message);
        }
      }
    }
