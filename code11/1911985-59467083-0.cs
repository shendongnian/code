using System;
using System.Numerics;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Util;
using System.Threading.Tasks;
using NBitcoin;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.HdWallet;
public class Program
{
    private static async Task Main(string[] args)
    {
       
        //Initiating a HD Wallet requires a list of words and an optional password to add further entropy (randomness)
        var words = "ripple scissors kick mammal hire column oak again sun offer wealth tomorrow wagon turn fatal";
        //Note: do not confuse the password with your Metamask password, Metamask password is used to secure the storage
        var password = "password";
        var wallet = new Wallet(words, password);
        // An HD Wallet is deterministic, it will derive the same number of addresses 
        // given the same seed (wordlist + optional password).
        // All the created accounts can be loaded in a Web3 instance and used as any other account, 
        // we can for instance check the balance of one of them:
        var account = new Wallet(words, password).GetAccount(0);
        Console.WriteLine("The account address is: " + account.Address);
        var web3 = new Web3(account, "http://testchain.nethereum.com:8545");
        //we connect to the Nethereum testchain which has already the account preconfigured with some Ether balance.
        var balance = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
        Console.WriteLine("The account balance is: " + balance.Value);
        //Or transfer some Ether, as the account already has the private key required to sign the transactions.
        var toAddress = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";
        var transactionReceipt = await web3.Eth.GetEtherTransferService()
            .TransferEtherAndWaitForReceiptAsync(toAddress, 2.11m, 2);
        Console.WriteLine($"Transaction {transactionReceipt.TransactionHash} for amount of 2.11 Ether completed");
    }
}
