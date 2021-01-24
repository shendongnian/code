        [Route("")]
        [HttpGet]
        public ActionResult<Book> GetByName(string name)
        {
            var book = _bookService.GetByAuthor(name);
    
            if (book == null)
                return NotFound();
    
            return book;
        }
