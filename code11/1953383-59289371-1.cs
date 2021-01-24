        /// <summary>
        /// Sets a value in the user's session.
        /// </summary>
        /// <param name="key">The key for the value.</param>
        /// <param name="value">The value.</param>
        [HttpPost]
        public IActionResult SessionString(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return new JsonResult(null);
        }
        /// <summary>
        /// Get a value from the user's session.
        /// </summary>
        /// <param name="key">The key for the value.</param>
        /// <returns>The value.</returns>
        [HttpGet]
        public IActionResult SessionString(string key)
        {
            string value = HttpContext.Session.GetString(key);
            return new JsonResult(value);
        }
    }
