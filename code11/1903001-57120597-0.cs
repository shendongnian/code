csharp
/// <summary>
        /// Method Add with similar code in Update method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public PersonResponse Add(PersonInsertRequest item)
        {
            
            var controller = new PersonController(classmates);
            Validator myValidator = request => controller.ValidateInsert((PersonInsertRequest)request);
            Executor myExecutor = request => controller.ExecuteInsert((PersonInsertRequest)request);
            var result = Execute(item, myValidator, myExecutor);
            return result as PersonResponse;
        }
        /// <summary>
        /// Method Update with similar code in Add method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public PersonResponse Update(PersonUpdateRequest item)
        {
            var controller = new PersonController(classmates);
            Validator myValidator = request => controller.ValidateUpdate((PersonUpdateRequest)request);
            Executor myExecutor = request => controller.ExecuteUpdate((PersonUpdateRequest)request);
            var result = Execute(item, myValidator, myExecutor);
            
            return result as PersonResponse;
        }
