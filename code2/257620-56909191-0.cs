    Using Aforge framework and Drawing.Imaging, worked for me!
        public static bool CompareBitmaps(Bitmap imageTemplate, Bitmap imagePattern)
        {
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.9f);
            // find all matchings with specified above similarity
            TemplateMatch[] matchings = tm.ProcessImage(imageTemplate, imagePattern);
                        
            bool retorno = false;
            try
            {
                if (matchings[0].Similarity > 0.95f)
                {
                    retorno = true;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }
