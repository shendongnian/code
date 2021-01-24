c#
var consultants =  from c in _context.Consultant
                                    select new
                                    {
                                        ConsultantID = c.ID,
                                        c.FullName
                                    };
                                   
            ViewData["Consultants"] = new MultiSelectList(consultants, "ConsultantID", "FullName", referral.ReferralConsultants.Select(r => r.ConsultantID).ToArray());
            return View(referral);
In the View
   <div class="form-group">
        <label class="control-label d-inline">
                    Consultants
        <select multiple name="selectedValues" class="form-control" asp-items="ViewBag.Consultants"></select>
        </label>
   </div>
This will send the selectedValues to my controller when I submit the form. Then I just need to get those values in my Edit [Post] and save them in the Database.
public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,RequesterID,DateIssued,DateRequested,Description,Type, Status")] Referral referral, string [] selectedValues)
