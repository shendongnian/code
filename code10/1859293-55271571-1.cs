    public async IActionResult Details(Int32? id)
    {
        if( id == null ) return this.NotFound();
        Question question = await this.db.Questions.SingleOrDefaultAsync( id.Value );
        if( question == null ) return this.NotFound();
        DetailsViewModel vm = new DetailsViewModel()
        {
            PageTitle = "Details for " + question.Title,
            TheQuestion = question,
            TheAnswers = await this.db.Answers.Where( q => a.Question == question ).ToListAsync()
        };
        return this.View( model: vm );
    }
