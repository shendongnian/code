    using System.Windows.Forms;
    using System.ServiceModel.Channels;
    
    ...
    
    var msg = new Message(); // ambiguous
    var msg1 = new System.Windows.Forms.Message(); // OK
    var msg2 = new System.ServiceModel.Channels.Message(); // OK
