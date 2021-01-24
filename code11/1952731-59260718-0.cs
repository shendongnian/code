// new model
public class JsonReceiveModel{
    public int Id {get;set;}
    public string Status {get;set;}
    public string Remark {get;set;}
}
// modifed to use model.Id, model.Status, model.Remark
public JsonResult saveStatus(JsonReceiveModel model) {
    int approvalId;
    if (model.Id == 0) {
        var staff = db.Staffs.Where(s => s.UserName == User.Identity.Name).FirstOrDefault();
        RequestForApproval ap = new RequestForApproval {
            RequestToStaffId = staff.Id,
                RequestDate = DateTime.Now,
        };
        db.RequestForApprovals.Add(ap);
        db.SaveChanges();
        approvalId = ap.Id;
    } else {
        approvalId = id;
    }
    Status stat = (Status) Enum.Parse(typeof(Status), status);
    ApprovalStatus temp = new ApprovalStatus {
        Id = approvalId,
            Remark = model.Remark,
            Status = model.Status,
            AddDate = DateTime.Now
    };
    db.ApprovalStatuses.Add(temp);
    db.SaveChanges();
    var df = db.ApprovalStatuses.Where(s => s.Id == approvalId).ToList();
    return Json(df);
}
Then include `contentType: 'application/json'` in your ajax call.
$.ajax({
    type: 'POST',
    dataType: 'json',
    url: '@Url.Action("saveStatus")',
    contentType: 'application/json',
    data: {
        id: bid,
        status: $("#enumId option:selected").val(),
        Remark: $('#message-text').val()
    },
    success: function(data) {
        bid.url(data);
        status.val('');
        mess.val('');
        alert("Success, sent data to controller");
    },
    error: function(data) {
        alert("Error: " + data);
    },
})
