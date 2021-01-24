using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using PassKit;
using UIKit;
namespace BlankNativeApp.iOS
{
    public class PKViewController : UIViewController, IPKAddPaymentPassViewControllerDelegate
    {
        public void DidFinishAddingPaymentPass(PKAddPaymentPassViewController controller, PKPaymentPass pass, NSError error)
        {
            // Perform Post Addition Functionality
        }
        public void GenerateRequestWithCertificateChain(PKAddPaymentPassViewController controller, NSData[] certificates, NSData nonce, NSData nonceSignature, [BlockProxy(typeof(NIDActionArity1V173))] Action<PKAddPaymentPassRequest> handler)
        {
            // Do work that needs to be done with certifications
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (!PKAddPaymentPassViewController.CanAddPaymentPass)
            {
                // use other payment method / alert user
            }
            var config = new PKAddPaymentPassRequestConfiguration(PKEncryptionScheme.Ecc_V2);
            var addPaymentPassVC = new PKAddPaymentPassViewController(config, this);
            View.BackgroundColor = UIColor.White;
            Title = "My Custom View Controller";
            var btn = UIButton.FromType(UIButtonType.System);
            btn.Frame = new CGRect(20, 200, 280, 44);
            btn.SetTitle("Click Me", UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => {
                //this.ShowViewController(addPaymentPassVC, (Foundation.NSObject)sender); This line will also work
                this.PresentViewControllerAsync(addPaymentPassVC, true);
            };
            View.AddSubview(btn);
        }
    }
}
 [![Implementation example for Passkit][4]][4]
  [1]: https://developer.apple.com/documentation/passkit/pkpasslibrary
  [2]: https://stackoverflow.com/a/46214137/11104068
  [3]: https://stackoverflow.com/a/51196768/11104068
  [4]: https://i.stack.imgur.com/Wdjt0.png
