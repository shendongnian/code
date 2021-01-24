var url = 'http://localhost:3112/PrintService';
var model = {
                               "PRINT_REQUEST": {
                                    "PRINT_NAME": "TSC TTP-345 (TEST)",
                                    "LABEL_QTY": 1,
                                    "TEMPLATE_PATH": "WD.LAB",
                                    "PRINT_DATA": [
                                                {
                                                    "storage": "",
                                                    "SPEC": "",
                                                    "ITEM": "",
                                                    "QTY": "500",
                                                    "DEMAND": "0",
                                                    "EXP_DATE1": "2021-05-21",
                                                    "EXP_DATE2": "2021-05-21",
                                                    "ALLERGENS": "",
                                                    "WD_DATE": "2019-10-29 23:59:59",
                                                    "WD_USER": "TEST",
                                                    "WD_USER_NAME": "TEST",
                                                    "TCI_LOTNO": "20190522",
                                                    "SHOP_ORDER": "",
                                                    "SHOP_ORDER_ITEM": "",
                                                    "SHOP_ORDER_DESC": "",
                                                    "SPLIT_SFC_COUNT": "",
                                                    "SUP_LOTNO": "",
                                                    "REPRINT": null,
                                                    "PACKCOUNT": "",
                                                    "SFC": "",
                                                    "WEIGHT": "",
                                                    "PCS": "",
                                                    "SKIN_WEIGHT": -500
                                                }
                                           ]
                                         }
                                      };
  $.ajax({
        type: "POST",
        url: url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(model),
        dataType: 'html',
        success: function (ret) {
            labeldata = ret;
            window.alert("OK");
        },
        error: function (ret) {
            window.alert(ret);
        }
    })
in controller side you can pass model like below.
public class PRINTDATA
{
    public string storage { get; set; }
    public string SPEC { get; set; }
    public string ITEM { get; set; }
    public string QTY { get; set; }
    public string DEMAND { get; set; }
    public string EXP_DATE1 { get; set; }
    public string EXP_DATE2 { get; set; }
    public string ALLERGENS { get; set; }
    public string WD_DATE { get; set; }
    public string WD_USER { get; set; }
    public string WD_USER_NAME { get; set; }
    public string TCI_LOTNO { get; set; }
    public string SHOP_ORDER { get; set; }
    public string SHOP_ORDER_ITEM { get; set; }
    public string SHOP_ORDER_DESC { get; set; }
    public string SPLIT_SFC_COUNT { get; set; }
    public string SUP_LOTNO { get; set; }
    public object REPRINT { get; set; }
    public string PACKCOUNT { get; set; }
    public string SFC { get; set; }
    public string WEIGHT { get; set; }
    public string PCS { get; set; }
    public int SKIN_WEIGHT { get; set; }
}
public class PRINTREQUEST
{
    public string PRINT_NAME { get; set; }
    public int LABEL_QTY { get; set; }
    public string TEMPLATE_PATH { get; set; }
    public List<PRINTDATA> PRINT_DATA { get; set; }
}
public class Model
{
    public PRINTREQUEST PRINT_REQUEST { get; set; }
}
