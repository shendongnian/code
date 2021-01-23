            if (vm.Description != "")
            {
                //HttpUtility.HtmlDecode needed because text in Description field is HtmlEncoded!
                consultants = consultants.Where(x => HttpUtility.HtmlDecode(x.Description).ContainsCaseInsensitive(vm.Description)).ToList();
            }
