       private void buttonCreateSubmit_Click(object sender, EventArgs e)
        {
            Body body = new Body
            {
                body_content = richTextBoxBody.Text
            };
            tnDBase.AddToBodies(body);
            tnDBase.SaveChanges();
            var genid = tnDBase.Genres.Single(g => g.genre_name == comboBoxGenre.Text);
            Article article = new Article()
            {
                article_name = textBoxTitle.Text,
                genre_id = genid.genre_id,
                status_id = 3,
                body_id = body.body_id
            };
            tnDBase.AddToArticles(article);
            tnDBase.SaveChanges();
         }
