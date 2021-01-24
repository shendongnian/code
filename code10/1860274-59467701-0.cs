csharp
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
public class GetStartedSmartContracts
{
    [Function("transfer", "bool")]
    public class TransferFunction : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
    public static async Task Main()
    {
        var url = "https://mainnet.infura.io";
        var web3 = new Web3(url);
				var txn = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync("0x622760ad1a0ead8d16641d5888b8c36cb67be5369556f8887499f4ad3e3d1c3d");
        var transfer = new TransferFunction().DecodeTransaction(txn);
				Console.WriteLine(transfer.TokenAmount);
				//BAT has 18 decimal places the same as Wei
				Console.WriteLine(Web3.Convert.FromWei(transfer.TokenAmount));
    }
}
You can test this in the http://playground.nethereum.com
