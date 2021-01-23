    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using photostorage.Models;
    
    namespace photostorage.Controllers
    {
        public class PhotosController : Controller
        {
            PhotosRepository objPhotosRepository = new PhotosRepository();
            //
            // GET: /Photos/
            public ActionResult ViewPhoto(string userid, int photoid)
            {
                photos CurrentPhoto = objPhotosRepository.GetPhotosById(photoid);
                if (CurrentPhoto == null)
                    return View("NotFound");
                else
                    return View("ViewPhoto", CurrentPhoto);
            }
        }
    }
