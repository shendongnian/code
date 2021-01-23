    using System;
    using System.Web.Mvc;
    using MySolution.Core.Interfaces.EntityFramework;
    using MySolution.Core.Interfaces.Repositories;
    namespace MySolution.Ux.Web.Site.Primitives
    {
        /// <summary>
        ///     Provides mechanisms for performing CRUD operations on entities within a RESTful environment.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        public abstract class CrudController<TEntity> : Controller 
            where TEntity : class, IEntity, new()
        {
            /// <summary>
            ///     The repository to use for CRUD operations on the entity. Derived classes
            ///     also have access to this repository so that the virtual actions can be
            ///     overridden with custom implementations.
            /// </summary>
            protected readonly IRepository<TEntity> Repository;
            /// <summary>
            ///     Initialises a new instance of the <see cref="CrudController{TEntity}"/> class.
            /// </summary>
            /// <param name="repository">The repository.</param>
            protected CrudController(IRepository<TEntity> repository)
            {
                // Instantiate the controller's repository.
                Repository = repository;
            }
            /// <summary>
            ///     Lists this specified entities within the data store.
            /// </summary>
            /// <returns>A JSON formatted list of the entities retrieved.</returns>
            [HttpGet]
            public virtual JsonResult List()
            {
                try
                {
                    return Json(Repository.GetAll(), JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(e.Message, JsonRequestBehavior.AllowGet);
                }
            }
            /// <summary>
            ///     Gets a specific entity within the data store.
            /// </summary>
            /// <returns>A JSON formatted version of the entity retrieved.</returns>
            [HttpGet]
            public virtual JsonResult Get(Guid id)
            {
                try
                {
                    return Json(Repository.Get(id), JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    // An error has occured. Handle the exceptions as needed and return feedback via JSON.
                    return Json(e.Message, JsonRequestBehavior.AllowGet);
                }
            }
            /// <summary>
            ///     Creates a specific entity within the data store.
            /// </summary>
            /// <returns>A JSON formatted version of the entity created.</returns>
            [HttpPost]
            public virtual JsonResult Create(TEntity entity)
            {
                try
                {
                    Repository.Add(entity);
                    Repository.Save();
                    return Json(entity);
                }
                catch (Exception e)
                {
                    // An error has occured. Handle the exceptions as needed and return feedback via JSON.
                    return Json(e.Message);
                }
            }
            /// <summary>
            ///     Updates a specific entity within the data store.
            /// </summary>
            /// <returns>A JSON formatted version of the entity updated.</returns>
            [HttpPut]
            public virtual JsonResult Update(TEntity entity)
            {
                try
                {
                    Repository.Update(entity);
                    Repository.Save();
                    return Json(entity);
                }
                catch (Exception e)
                {
                    // An error has occured. Handle the exceptions as needed and return feedback via JSON.
                    return Json(e.Message);
                }
            }
            /// <summary>
            ///     Deletes a specific entity from the data store.
            /// </summary>
            /// <returns>A JSON formatted version of the entity deleted.</returns>
            [HttpDelete]
            public virtual JsonResult Delete(Guid id)
            {
                try
                {
                    var entity = Repository.Get(id);
                    Repository.Remove(entity);
                    Repository.Save();
                    return Json(entity);
                }
                catch (Exception e)
                {
                    // An error has occured. Handle the exceptions as needed and return feedback via JSON.
                    return Json(e.Message);
                }
            }
        }
    }
