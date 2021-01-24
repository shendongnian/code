        /// <summary>
        /// Tries the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public static HttpStatusCodeResult Try(Action action, ModelState model)
        {
            if (!model.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            try
            {
                action();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception) { return new HttpStatusCodeResult(HttpStatusCode.InternalServerError); }
        }
