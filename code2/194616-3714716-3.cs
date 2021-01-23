    var wWidget = new Widget();
    wWidget.publicVar = "I have overridden the public property";
    var strSummary = wWidget.publish(fnSummary);
    var strDetails = wWidget.publish(fnDetails);
    console.log(strSummary,strDetails);
