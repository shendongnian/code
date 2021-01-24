            try
            {
                if (_regRep.btnNext.Displayed && _regRep.btnNext.Enabled)
                {
                     objCommon.Click(_regRep.btnNext);
                    _fleetRep.btnDelete(Fleetname).Click();
                }
            }
            catch (Exception ex)
            {
                _fleetRep.btnDelete(Fleetname).Click();
                Console.WriteLine("No delete found: " + ex.Message);
            }
