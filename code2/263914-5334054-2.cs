        public static Post GetNewPost(string title, string bodyMarkup, DateTime posted)
        {
            var post = new Post(0, title, bodyMarkup, posted, new List<Comment>());
            var fieldLengthSpec = new PostFieldLengthSpecification();
            if (fieldLengthSpec.IsSatisfiedBy(post))
                return post;
            else
                throw new InvariantException(post, fieldLengthSpec.GetErrors(post));
        }
